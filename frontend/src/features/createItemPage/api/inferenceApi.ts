import { api } from "../../../shared/api/api";

export async function removeBackground(file: Blob): Promise<Blob> {
    const formData = new FormData();
    formData.append("Image", file);

    console.log("procsd")


    const processedImage = await api.inference.inference(formData);
        console.log(processedImage.data)

    return processedImage.data;
}