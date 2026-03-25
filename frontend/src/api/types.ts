export interface ClothingItemDto {
  id: string;
  name: string | null;
  category: string | null;
  description?: string | null;
  size?: string | null;
  material?: string | null;
  color?: string | null;
  price?: PriceDto;
  imageId: string;
  createdAt?: string;
  updatedAt?: string;
}

export interface PriceDto {
  amount?: number;
  currency?: string | null;
}

