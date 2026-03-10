export interface ClothingItem {
    id: string,
    name: string,
    catergory: string,
    imageId: string
}

export interface ClothingResponseDto {
    clothingResponses: ClothingItem[]
}