import { api } from "../../../shared/api/api";

export async function removeBackground(file: Blob): Promise<Blob> {
    const formData = new FormData();
    formData.append("Image", file);

    const processedImage = await api.inference.inference(formData);
    return processedImage.data;
}