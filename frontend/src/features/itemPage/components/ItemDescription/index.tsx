import { ClothingItemLabels, type ClothingItemDto } from "../../../clothing/clothing.types";

type Props = {
    item: ClothingItemDto
}

const ItemDescription = ({ item }: Props) => {
    return (
        <div className="w-full">
            <div className="w-full pt-3 my-4 bg-bg-elevated rounded-xl p-4">
                <h1 className="text-2xl font-semibold my-2">{item?.name}</h1>
                <h2 className="mt-2 mb-5 text-text-sub">{item?.category}</h2>
                <dl className="grid grid-cols-2 gap-3">
                    {Object.entries(ClothingItemLabels).map(([key, label]) => {
                        const value = item?.[key as keyof ClothingItemDto];

                        if (key === "price") {
                            const price = item?.price;

                            return (
                                <div key={key} className="">
                                    <dt className="font-semibold">{label}</dt>
                                    <dd>{price?.amount ?? "-"} {price?.currency ?? ""}</dd>
                                </div>
                        );                      
                        }

                        if (typeof value === "object") return null;

                        return (
                            <div key={key}>
                                <dt className="font-semibold">{label}</dt>
                                <dd>{value !== "" && value ? value : "-"}</dd>
                            </div>
                        );
                    })}
                </dl>
            </div>
            <div className="w-full pt-3 my-4  bg-bg-elevated rounded-xl p-4">
                <h1 className="text-lg font-semibold my-2">Tags</h1>
                Coming soon...
            </div>
        </div>
    );
}

export default ItemDescription;