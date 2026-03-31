import { useEffect, useState } from "react";
import type { ApiActions } from "../api/api.types";

interface UseBlobState { 
    url: string | null;
    isLoading: boolean,
    error: Error | null,
}

export interface UseBlobReturn extends UseBlobState, ApiActions { }

export function useBlob(fetcher: () => Promise<Blob>): UseBlobReturn {
    const [ state, setState ] = useState<UseBlobState>({
        url: null,
        isLoading: true,
        error: null,
    });

    const fetchImage = (): () => void => {
        let objectUrl: string;

        fetcher()
            .then(blob => {
                objectUrl = URL.createObjectURL(blob);
                setState(prev => ({ ...prev, url: objectUrl}));
            })
            .catch(e => {
                setState(prev => ({ ...prev, isLoading: false, error: e}));
            })
            .finally(() => {
                setState(prev => ({ ...prev, isLoading: false, error: null}));
            })
        
        return () => {
            if (objectUrl) URL.revokeObjectURL(objectUrl);
        }
    }

    useEffect(() => {
        const cleanup = fetchImage();
        return cleanup;
    }, []);

    return {
        ...state,
        refetch: fetchImage
    }
}