import type { ClothingMeta, ClothingMetaResponse } from "../../models/ClothingMeta";

export const mapClothingMeta = (raw: ClothingMetaResponse): ClothingMeta => ({
    total: raw.totalItems,
    categories: Object.fromEntries(raw.availableCategories.map(c => [c.category, c.count])),
    colors: Object.fromEntries(raw.availableColors.map(c => [c.color, c.count])),
    sizes: Object.fromEntries(raw.availableSizes.map(c => [c.size, c.count])),
    materials: Object.fromEntries(raw.availableMaterials.map(c => [c.material, c.count])),
    minPrice: raw.minPrice,
    maxPrice: raw.maxPrice,
})