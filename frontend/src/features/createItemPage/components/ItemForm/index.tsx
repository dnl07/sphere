import type { CreateClothingItemRequest } from "../../../clothing/api/clothingApi.types";

const FIELDS: { name: keyof CreateClothingItemRequest; label: string, placeholder: string, type?: string }[] = [
    { name: "name", label: "Name", placeholder: "Red Bull jacket" },
    { name: "category", label: "Category", placeholder: "placeholder" },
    { name: "size", label: "Size", placeholder: "L" },
    { name: "material", label: "Material", placeholder: "Fabric" },
    { name: "color", label: "Color", placeholder: "Blue" },
    { name: "brand", label: "Brand", placeholder: "Hollister" },
    { name: "store", label: "Store", placeholder: "Hollister" },
    { name: "boughtAt", label: "Bought At", placeholder: "placeholder", type: "date" },
    { name: "notes", label: "Notes", placeholder: "Fresh blue red bull jacket" },  
    { name: "isArchived", label: "Is Archived", placeholder: "placeholder", type: "checkbox" }, 
]

type Props = {
    request: Partial<CreateClothingItemRequest> | null,
    updateRequest: (fields: Partial<CreateClothingItemRequest>) => void
}

const ItemForm = ({ request, updateRequest }: Props) => {
    return(
        <div className="w-full text-2xl border-t py-2">
            <div className="flex flex-col gap-6 mb-10">
                {FIELDS.map(({name, label, placeholder, type}) => (
                    <div className={`flex gap-2 ${type === "checkbox" ? "flex-row items-center justify-between" : "flex-col"}`} key={name}>
                        <h3 className="text-2xl">{label}</h3>
                        {type === "checkbox" ? 
                            <div  
                                className={`w-6 h-6 border-2 cursor-pointer transition-all duration-150 ${request?.[name] ? "bg-black" : ""}`}
                                onClick={() => updateRequest({ [name]: !request?.[name] })}
                            />
                        : 
                            <input 
                                type={type ?? "text"}
                                placeholder={placeholder}
                                value={(request?.[name] as string) ?? ""}
                                onChange={e => updateRequest({ [name]: e.target.value })}
                                className="text-xl border-2 px-4 py-2"
                            />                        
                        }
                    </div>
                ))}
            </div>

        </div>
    )
};

export default ItemForm;