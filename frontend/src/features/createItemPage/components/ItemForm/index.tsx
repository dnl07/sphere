import Dropdown from "../FormDropDown";
import type { CreateClothingItemRequest } from "../../../clothing/api/clothingApi.types";
import type { ClothingValidationErrors } from "../../../clothing/hooks/useCreateClothingItem";
import { useGetCategories } from "../../../clothing/hooks/useGetCategories";
import Card from "../../../../shared/components/layout/Card";

const FIELDS: { name: keyof CreateClothingItemRequest; label: string, placeholder: string, type?: string, required?: boolean }[] = [
    { name: "category", label: "Category", placeholder: "placeholder", required: true, type: "dropdown" },
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
    updateRequest: (fields: Partial<CreateClothingItemRequest>) => void,
    validationErrors: ClothingValidationErrors
}

const ItemForm = ({ request, updateRequest, validationErrors }: Props) => {
    const { categories } = useGetCategories();

    const displayField = (name: keyof CreateClothingItemRequest, placeholder: string, type?: string) => {
        if (type === "checkbox") {
            return ((
                <div  
                    className={`w-6 h-6 rounded-md aspect-square bg-bg-elevated border-2 cursor-pointer transition-all duration-150 ${request?.[name] ? "bg-black" : ""}`}
                    onClick={() => updateRequest({ [name]: !request?.[name] })}
                />
            ));
        } else if (type === "dropdown") {
            return (
                <Dropdown values={categories ?? ["No categories found"]} setValue={(value: string) => updateRequest({ [name]: value })}/>
            );
        } else {
            return (
                <input 
                    type={type ?? "text"}
                    placeholder={placeholder}
                    value={(request?.[name] as string) ?? ""}
                    onChange={e => updateRequest({ [name]: e.target.value })}
                    className="text-xl border-2 rounded-xl border-border bg-bg-sunken px-4 py-2"
                /> 
            );
        }
    }

    return(
        <Card title="Details">
            <div className="flex flex-col gap-6">
                {FIELDS.map(({name, label, placeholder, type, required}) => (
                    <div className={`flex gap-2 ${type === "checkbox" ? "flex-row items-center justify-between" : "flex-col"}`} key={name}>
                        <div className="w-full flex flex-row justify-between items-end">
                            <h3 className="text-lg">{label}{required && "*"}</h3>
                            <span className="text-red-700 text-md">{validationErrors[name]}</span>                           
                        </div>
                        {displayField(name, placeholder, type)}
                    </div>
                ))}
            </div>

        </Card>
    )
};

export default ItemForm;