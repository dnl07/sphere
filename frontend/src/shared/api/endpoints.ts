export const API_BASE = "/api";

export const clothingEndpoints = {
    getItem : (id: string) => `/clothing/${id}`,
    createClothing : () => `${API_BASE}/clothing`,
    getAll: () => `${API_BASE}/clothing`,
    getImage: (id: string) => `${API_BASE}/image/${id}`,
    inference: () => `${API_BASE}/inference`
}