import { Fragment } from "react";
import { ClothingItemLabels, type ClothingItemDto } from "../../../clothing/clothing.types";

type Props = {
    item: ClothingItemDto
}

const ItemDescription = ({ item }: Props) => {
    return (
        <div className="w-full pt-3">
            <dl className="flex flex-col gap-3">
                {Object.entries(ClothingItemLabels).map(([key, label]) => {
                    const value = item?.[key as keyof ClothingItemDto];

                    if (key === "price") {
                        const price = item?.price;

                        return (
                            <div key={key} className="">
                                <dt className="font-bold">{label}</dt>
                                <dd>{price?.amount ?? "-"} {price?.currency ?? ""}</dd>
                            </div>
                    );                      
                    }

                    if (typeof value === "object") return null;

                    return (
                        <div key={key}>
                            <dt className="font-bold">{label}</dt>
                            <dd>{value ?? "-"}</dd>
                        </div>
                    );
                })}
            </dl>
        </div>
    );
}

export default ItemDescription;