export const API_BASE = import.meta.env.VITE_API_URL || "http://localhost:5000/api";

export const clothingEndpoints = {
    createClothing : () => `${API_BASE}/clothing`,
    getAll: () => `${API_BASE}/clothing`,
    getImage: (id: string) => `${API_BASE}/image/${id}`,
    inference: () => `${API_BASE}/inference`
}