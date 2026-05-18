import type { UpdateClothingItemByIdRequest } from "../../../clothing/api/clothingApi.types"
import type { ClothingItemDto } from "../../../clothing/clothing.types"

export type ItemField = {
    key: keyof ClothingItemDto
    updateKey: keyof UpdateClothingItemByIdRequest | null
    label: string
}

export const ProductDetailsLabels: ItemField[] = [
    { key: "category", updateKey: "category", label: "Category" },
    { key: "size", updateKey: "size", label: "Size" },
    { key: "color", updateKey: "color", label: "Color" },
    { key: "material", updateKey: "material", label: "Material" },
    { key: "brand", updateKey: "brand", label: "Brand" },
]

export const PurchaseLabels: ItemField[] = [
    { key: "price", updateKey: "price", label: "Price" },
    { key: "boughtAt", updateKey: "boughtAt", label: "Bought at" },
    { key: "store", updateKey: "store", label: "Store" },
]

export const MetaDataLabels: ItemField[] = [
    { key: "isArchived", updateKey: "isArchived", label: "Status" },
    { key: "createdAt", updateKey: null, label: "Created on" },
    { key: "updatedAt", updateKey: null, label: "Updated on" },
]
