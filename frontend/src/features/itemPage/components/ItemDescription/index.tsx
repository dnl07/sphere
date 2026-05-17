import { useState } from "react";
import Card from "../../../../shared/components/layout/Card";
import { convertDateFormat, isIsoDateString } from "../../../../shared/utils/dateUtils";
import type { UpdateClothingItemByIdRequest } from "../../../clothing/api/clothingApi.types";
import { type ClothingItemDto } from "../../../clothing/clothing.types";
import { MetaDataLabels, ProductDetailsLabels, PurchaseLabels, type ItemField } from "./constants";
import DropDownArrow from "../../../../shared/components/ui/icons/DropDownArrow";
import FormDropdown from "../../../createItemPage/components/FormDropDown";
import { useGetCategories } from "../../../clothing/hooks/useGetCategories";

type Props = {
    item: ClothingItemDto,
    toUpdate: boolean,
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
        notes: item.notes
    });

    const { categories } = useGetCategories();

    const handleChange = (key: keyof UpdateClothingItemByIdRequest | null, value: string) => {
        if (!key) return;

        const updated = { ...formData, [key]: value };
        setFormData(updated);
        updateRequest(updated);
    };

    const renderField = (key: string, field: ItemField, value: ClothingItemDto[keyof ClothingItemDto]) => {
        let displayValue: string;

        if (value === undefined || value === null || value === "") {
            value = "-"
        }

        if (field.key === "price") {
            const price = item.price;
            return (
                <div key={key} className="">
                    <dt className="text-text-sub uppercase tracking-wide text-sm">{field.label}</dt>
                    <dd>{price ?? "-"}€</dd>
                </div>
            );                      
        }

        if (field.key === "isArchived") {
            const isArchived = item.isArchived;
            return (
                <div key={key}>
                    <dt className="text-text-sub uppercase tracking-wide text-sm">{field.label}</dt>
                    <dd>{isArchived ? "Archived" : "Not archived"}</dd>
                </div>
            );                
        }

        if (field.key === "category" && toUpdate) {
            return (
                <div key={key}>
                    <dt className="text-text-sub uppercase tracking-wide text-sm">{field.label}</dt>
                    <FormDropdown 
                        className="border-2 rounded-sm py-1 px-2 text-black w-50 mt-2" 
                        values={categories ?? ["No categories found"]} 
                        setValue={(value: string) => updateRequest({ ["category"]: value })}
                    />
                </div>
            )
        }

        if (typeof value !== "string") return null;

        if (isIsoDateString(value)) {
            const date = convertDateFormat(value);
            displayValue = date || "-";
        } else {
            displayValue = value;
        }

        return (
            <div key={key}>
                <dt className="text-text-sub uppercase tracking-wide text-sm">{field.label}</dt>
                {toUpdate ? (
                    <input 
                        onChange={(e) => handleChange(field.updateKey, e.target.value)} 
                        className="border-2 rounded-sm py-1 px-2 mt-2 w-50" 
                        value={String(formData[field.updateKey!] ?? "")}
                    />
                ) : (
                    <dd>{displayValue}</dd>
                )}
            </div>
        );
    }

    const displayData = (item: ClothingItemDto, fields: ItemField[]) => {
        return (
            <div className="grid grid-cols-2 gap-4 text-md">
                {fields.map((field, idx) => 
                    renderField(String(idx), field, item[field.key])
                )}                
            </div>
        )
    }

    return (
        <div className="w-full flex gap-4 flex-col">
            <Card title="Product Details" className="md:col-start-1 md:col-end-1">
                {displayData(item, ProductDetailsLabels)}
            </Card>
            <Card title="Purchase Information">
                {displayData(item, PurchaseLabels)}
            </Card>
            <Card title="Notes">
                {toUpdate ? (
                    <input 
                        onChange={(e) => handleChange("notes", e.target.value)} 
                        className="border-2 rounded-sm py-1 px-2 mt-2" 
                        value={formData.notes ?? ""}
                    />
                ) : (
                    <dd>{formData.notes}</dd>
                )}
            </Card>
            <Card title="Tags">
                Coming soon...
            </Card>            
            <Card title="Metadata">
                {displayData(item, MetaDataLabels)}
            </Card>
        </div>
    );
}

export default ItemDescription;