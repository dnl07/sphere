import { useEffect, useState } from "react";
import { useApi } from "../api/useApi";

export function useBlob(fetcher: () => Promise<Blob>) {
    const { execute, data, ...state } = useApi(fetcher, { initialLoading: true})

    const [url, setUrl ] = useState<string | null>(null);

    useEffect(() => {
        let objectUrl: string;

         execute().then(blob => {
            if (!blob) return;
            objectUrl = URL.createObjectURL(blob);
            setUrl(objectUrl);
        });
        
        return () => {
            if (objectUrl) URL.revokeObjectURL(objectUrl);
        }
    }, []);

    return {
        ...state,
        imageUrl: url
    }
}