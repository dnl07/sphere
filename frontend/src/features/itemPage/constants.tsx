import type { ReactNode } from "react"
import type { UpdateClothingItemByIdRequest } from "../clothing/api/clothingApi.types"
import type { ClothingItemDto } from "../clothing/clothing.types"
import FormDropdown from "../createItemPage/components/FormDropDown"
import Checkbox from "../../shared/components/ui/Checkbox"

export type ItemField = {
    key: keyof ClothingItemDto
    label: string
    updateKey: keyof UpdateClothingItemByIdRequest | null
    updateField: null | ((value: unknown, onChange: (value: string) => void, defaultValue?: string) => ReactNode)
}

export const ProductDetailsLabels: ItemField[] = [
    {
        key: "category",
        updateKey: "category",
        label: "Category",
        updateField: (value, onChange, defaultValue) => (
            <FormDropdown
                className="border-2 rounded-sm py-1 px-2 text-black w-[90%] mt-2"
                values={value as string[]}
                setValue={onChange}
                defaultValue={defaultValue}
            />
        ),
    },
    {
        key: "size",
        updateKey: "size",
        label: "Size",
        updateField: (value, onChange) => createInputField(value, onChange),
    },
    {
        key: "color",
        updateKey: "color",
        label: "Color",
        updateField: (value, onChange) => createInputField(value, onChange),
    },
    {
        key: "material",
        updateKey: "material",
        label: "Material",
        updateField: (value, onChange) => createInputField(value, onChange),
    },
    {
        key: "brand",
        updateKey: "brand",
        label: "Brand",
        updateField: (value, onChange) => createInputField(value, onChange),
    },
]

export const PurchaseLabels: ItemField[] = [
    {
        key: "price",
        updateKey: "price",
        label: "Price",
        updateField: (value, onChange) => createInputField(value, onChange),
    },
    { key: "boughtAt", updateKey: "boughtAt", label: "Bought at", updateField: null },
    {
        key: "store",
        updateKey: "store",
        label: "Store",
        updateField: (value, onChange) => createInputField(value, onChange),
    },
]

export const MetaDataLabels: ItemField[] = [
    {
        key: "isArchived",
        updateKey: "isArchived",
        label: "Status",
        updateField: (value, onChange) => {
            const v = value as boolean
            return <Checkbox defaultValue={v} onChange={(checked: boolean) => onChange(String(checked))} size="4" />
        },
    },
    { key: "createdAt", updateKey: null, label: "Created on", updateField: null },
    { key: "updatedAt", updateKey: null, label: "Updated on", updateField: null },
]

const createInputField = (value: unknown, onChange: (value: string) => void) => {
    return (
        <input
            onChange={(e) => onChange(e.target.value)}
            className="border-2 rounded-sm py-1 px-2 mt-2 w-[90%]"
            value={value as string}
        />
    )
}
