export interface ApiState<T> {
    data: T | null;
    isLoading: boolean;
    error: Error | null;
}

export interface ApiActions {
    refetch: () => void;
}