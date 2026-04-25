import { useSearchParams } from "react-router";

export const useMultiParam = (paramKey: string, exclusive: boolean = false) => {
    const [searchParams, setSearchParams] = useSearchParams();
    const values = searchParams.get(paramKey)?.split(",") ?? [];

    const toggle = (value: string) => {
        const params = new URLSearchParams(searchParams);

        if (exclusive) {
            params.set(paramKey, value)
        } else {
            const next = values.includes(value)
                ? values.filter(v => v !== value)
                : [...values, value];

            if (next.length === 0) {
                params.delete(paramKey);
            } else {
                params.set(paramKey, next.join(","));
            }
        }

        setSearchParams(params);        
    }

    return { values, toggle };
}

export default useMultiParam;