export interface ApiState<T> {
    data: T | null;
    isLoading: boolean;
    error: Error | null;
}

export interface ApiActions<T = void> {
    refetch: (args: T) => void;
}