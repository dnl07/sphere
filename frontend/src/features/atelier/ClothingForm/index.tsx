import { useState, type ChangeEvent } from "react";
import { useBackgroundRemover } from "../../createItemPage/hooks/useBackgroundRemover";
import Button from "../../../shared/components/ui/Button";

interface ClothingItemDto {
    name: string;
    category: string;
    description?: string;
    color?: string;
    material?: string;
    image?: File | null;
}

const ClothingForm = () => {
    const [ form, setForm ] = useState<ClothingItemDto>({
        name: "",
        category: "",
        description: "",
        color: "",
        material: "",
        image: null
    });

    const [ preview, setPreview ] = useState<string | null>(null);

    const { processImage } = useBackgroundRemover();

    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setForm(prev => ({ ...prev, [name]: value}));
    }

    const handleSubmit = async () => {        
        const formData = new FormData();

        formData.append("name", form.name);
        formData.append("category", form.category);
        if (form.description) formData.append("description", form.description);
        if (form.color) formData.append("color", form.color);
        if (form.material) formData.append("material", form.material);
        if (form.image) formData.append("image", form.image);

        // await create(formData);
    }

    const handleFileChange = (e: ChangeEvent<HTMLInputElement>) => {
        const file = e.target.files?.[0];
        if (!file) return;

        setForm(prev => ({...prev, image: file}));

        const url = URL.createObjectURL(file);
        setPreview(url);
    }

    const removeBackground = () => {
        const file = form.image;

        if (!file) return;

        processImage(file);
    }

    const removeImage = () => {
        setForm(prev => ({...prev, image: null}));
        setPreview(null);
    }

    return (
        <div>
            <div>
                <h2>Clothing Form</h2>
                <form>
                    <div>
                        <label htmlFor="name">Name</label>
                        <input name="name" value={form.name} onChange={handleChange} />
                    </div>
                    <div>
                        <label htmlFor="category">Category</label>
                        <input name="category" value={form.category} onChange={handleChange} />
                    </div>
                    <div>
                        <label htmlFor="description">Description</label>
                        <input name="description" value={form.description} onChange={handleChange} />
                    </div> 
                    <div>
                        <label htmlFor="color">Color</label>
                        <input name="color" value={form.color} onChange={handleChange} />
                    </div>
                    <div>
                        <label htmlFor="material">Material</label>
                        <input name="material" value={form.material} onChange={handleChange} />
                    </div>
                </form> 
            </div>
            <div>
                <Button onClick={() => handleSubmit()}>Submit</Button>

                <h2>Image</h2>
                <div>
                    <label htmlFor="image">Upload an image</label>
                    <input type="file" name="image" accept="image/png, image/jpeg" onChange={handleFileChange}/>
                </div>
            </div>
            {preview &&
                <div>
                    <p>Image Preview:</p>
                    <img src={preview} alt="Preview" style={{ maxWidth: "400px", maxHeight: "400px" }} />
                    <Button onClick={() => removeBackground()}>Remove background</Button>
                    <Button onClick={() => removeImage()}>Remove image</Button>
                </div>    
            }
        </div>
    )
}

export default ClothingForm;