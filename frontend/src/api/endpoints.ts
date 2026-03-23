export const API_BASE = "/api";

export const clothingEndpoints = {
    createClothing : () => `${API_BASE}/clothing`,
    getAll: () => `${API_BASE}/clothing`,
    getMeta: () => `${API_BASE}/clothing/meta`,
    getImage: (id: string) => `${API_BASE}/image/${id}`,
    inference: () => `${API_BASE}/inference`
}