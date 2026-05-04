import Card from "../../../../shared/components/layout/Card";
import { convertDateFormat, isIsoDateString } from "../../../../shared/utils/dateUtils";
import { type ClothingItemDto } from "../../../clothing/clothing.types";
import { MetaDataLabels, ProductDetailsLabels, PurchaseLabels } from "./labels";

type Props = {
    item: ClothingItemDto
}

const ItemDescription = ({ item }: Props) => {
    const displayData = (item: ClothingItemDto, labels: Partial<Record<keyof ClothingItemDto, string>>) => {
        const renderField = (key: string, label: string, value: ClothingItemDto[keyof ClothingItemDto]) => {
            let displayValue: string;

            if (value === undefined || value === null || value === "") {
                value = "-"
            }

            if (key === "price") {
                const price = item.price;
                return (
                    <div key={key} className="">
                        <dt className="text-text-sub uppercase tracking-wide text-sm">{label}</dt>
                        <dd>{price?.amount ?? "-"} {price?.currency ?? ""}</dd>
                    </div>
                );                      
            }

            if (key === "isArchived") {
                const isArchived = item.isArchived;
                return (
                    <div key={key}>
                        <dt className="text-text-sub uppercase tracking-wide text-sm">{label}</dt>
                        <dd>{isArchived ? "Archived" : "Not archived"}</dd>
                    </div>
                );                
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
                    <dt className="text-text-sub uppercase tracking-wide text-sm">{label}</dt>
                    <dd>{displayValue}</dd>
                </div>
            );
        }

        return (
            <div className="grid grid-cols-2 gap-4 text-md">
                {Object.entries(labels).map(([key, label]) => 
                    renderField(key, label, item[key as keyof ClothingItemDto])
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
                {item.notes ?? "-"}
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