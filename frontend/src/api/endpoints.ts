export const API_BASE = "";

export const clothingEndpoints = {
    createClothing : () => `${API_BASE}/clothing`,
    getAll: () => `${API_BASE}/clothing`,
    getImage: (id: string) => `${API_BASE}/image/${id}`,
    inference: () => `${API_BASE}/inference`
}