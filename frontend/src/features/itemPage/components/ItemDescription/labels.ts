import type { ClothingItemDto } from "../../../clothing/clothing.types";

export const ProductDetailsLabels: Partial<Record<keyof ClothingItemDto, string>> = {
    category: "Category",
    size: "Size",
    color: "Color",
    material: "Material",
    price: "Price",
    brand: "Brand",
}

export const PurchaseLabels: Partial<Record<keyof ClothingItemDto, string>> = {
    boughtAt: "Bought at",
    store: "Store",
}

export const MetaDataLabels: Partial<Record<keyof ClothingItemDto, string>> = {
    isArchived: "Status",
    createdAt: "Created At",
    updatedAt: "Updated At",
}