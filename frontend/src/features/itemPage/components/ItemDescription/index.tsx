import { useState, type ReactNode } from "react"
import Card from "../../../../shared/components/layout/Card"
import { convertDateFormat, isIsoDateString } from "../../../../shared/utils/dateUtils"
import type { UpdateClothingItemByIdRequest } from "../../../clothing/api/clothingApi.types"
import { type ClothingItemDto } from "../../../clothing/clothing.types"
import { useGetCategories } from "../../../clothing/hooks/useGetCategories"
import { MetaDataLabels, ProductDetailsLabels, PurchaseLabels, type ItemField } from "../../constants"

type Props = {
    item: ClothingItemDto
    toUpdate: boolean
    updateRequest: (fields: Partial<UpdateClothingItemByIdRequest>) => void
}

const ItemDescription = ({ item, toUpdate, updateRequest }: Props) => {
    const [formData, setFormData] = useState<UpdateClothingItemByIdRequest>({
        category: item.category ?? undefined,
        size: item.size ?? undefined,
        color: item.color ?? undefined,
        material: item.material ?? undefined,
        brand: item.brand ?? undefined,
        price: item.price ?? undefined,
        boughtAt: item.boughtAt ?? undefined,
        store: item.store ?? undefined,
        notes: item.notes,
        isArchived: item.isArchived,
    })

    const { categories } = useGetCategories()

    const handleChange = (key: keyof UpdateClothingItemByIdRequest | null, value: string) => {
        if (!key) return

        const parsed = key === "isArchived" ? value === "true" : value
        const updated = { ...formData, [key]: parsed }
        setFormData(updated)
        updateRequest(updated)
    }

    const renderField = (key: string, field: ItemField, value: ClothingItemDto[keyof ClothingItemDto]) => {
        const renderFieldBox = (label: string, child: ReactNode | string, updateChild?: ReactNode) => {
            return (
                <div key={key}>
                    <dt className="text-text-sub uppercase tracking-wide text-sm">{label}</dt>
                    {toUpdate && updateChild ? <dd>{updateChild}</dd> : <dd>{child}</dd>}
                </div>
            )
        }

        let displayValue: string

        if (value === undefined || value === null || value === "") {
            value = "-"
        }

        if (field.key === "price") {
            const price = formData.price ? `${formData.price}€` : "-"
            return renderFieldBox(
                field.label,
                price,
                <>
                    {field.updateField?.(formData[field.updateKey!] ?? "", (value) =>
                        handleChange(field.updateKey, value)
                    )}
                    <span> €</span>
                </>
            )
        }

        if (field.key === "isArchived") {
            return renderFieldBox(
                field.label,
                `${formData.isArchived ? "Archived" : "Not archived"}`,
                <div className="flex gap-2 items-center">
                    {field.updateField?.(formData[field.updateKey!] ?? false, (value) =>
                        handleChange(field.updateKey, value)
                    )}
                    <span>{`${formData.isArchived ? "Archived" : "Not archived"}`}</span>
                </div>
            )
        }

        if (field.key === "category") {
            return renderFieldBox(
                field.label,
                formData.category,
                field.updateField?.(
                    categories ?? [],
                    (value) => handleChange(field.updateKey, value),
                    formData.category
                )
            )
        }

        if (typeof value !== "string") return null

        if (isIsoDateString(value)) {
            const date = convertDateFormat(value)
            displayValue = date || "-"
        } else {
            displayValue = value
        }

        return renderFieldBox(
            field.label,
            displayValue,
            field.updateField?.(String(formData[field.updateKey!] ?? ""), (value) =>
                handleChange(field.updateKey, value)
            )
        )
    }

    const displayData = (item: ClothingItemDto, fields: ItemField[]) => {
        return (
            <div className="grid grid-cols-2 gap-4 text-md">
                {fields.map((field, idx) => renderField(String(idx), field, item[field.key]))}
            </div>
        )
    }

    return (
        <div className="w-full flex gap-4 flex-col">
            <Card title="Product Details" className="md:col-start-1 md:col-end-1">
                {displayData(item, ProductDetailsLabels)}
            </Card>
            <Card title="Purchase Information">{displayData(item, PurchaseLabels)}</Card>
            <Card title="Notes">
                {toUpdate ? (
                    <textarea
                        onChange={(e) => handleChange("notes", e.target.value)}
                        className="border-2 rounded-sm py-1 px-2 mt-2 w-full h-30 flex justify-content-start"
                        value={formData.notes ?? ""}
                    />
                ) : (
                    <dd>{formData.notes ?? "no notes"}</dd>
                )}
            </Card>
            <Card title="Tags">Coming soon...</Card>
            <Card title="Metadata">{displayData(item, MetaDataLabels)}</Card>
        </div>
    )
}

export default ItemDescription
