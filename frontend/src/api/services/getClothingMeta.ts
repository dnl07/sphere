import type { ClothingMeta, ClothingMetaResponse } from "../../models/ClothingMeta";
import axiosInstance from "../axiosInstance";
import { clothingEndpoints } from "../endpoints";
import { mapClothingMeta } from "../mappers/clothingMetaMapper";

export const getClothingMeta = async (): Promise<ClothingMeta> => {
    const response = await axiosInstance.get<ClothingMetaResponse>(clothingEndpoints.getMeta())
    return mapClothingMeta(response.data);
};