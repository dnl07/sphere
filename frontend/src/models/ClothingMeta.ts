export interface ClothingMetaResponse {
    totalItems: number,
    availableCategories: { category: string, count: number }[],
    availableColors: { color: string, count: number }[],
    availableSizes: { size: string, count: number }[],
    availableMaterials: { material: string, count: number }[],
    minPrice: number,
    maxPrice: number,
}

export interface ClothingMeta {
    total: number,
    categories: Record<string, number>,
    colors: Record<string, number>,
    materials: Record<string, number>,
    sizes: Record<string, number>,
    minPrice: number,
    maxPrice: number,
}