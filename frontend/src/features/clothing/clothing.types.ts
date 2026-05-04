export interface ClothingItemDto {
  id: string;
  category: string | null;
  description?: string | null;
  size?: string | null;
  material?: string | null;
  color?: string | null;
  price?: PriceDto;
  boughtAt?: string,
  store?: string | null,
  brand?: string | null,
  isArchived: boolean,
  notes?: string | null,  
  imageId: string;
  createdAt?: string;
  updatedAt?: string;
}

export interface PriceDto {
  amount?: number;
  currency?: string | null;
}

export const ClothingItemLabels: Partial<Record<keyof ClothingItemDto, string>> = {
  size: "Size",
  material: "Material",
  color: "Color",
  price: "Price",
  boughtAt: "Bought at",
  store: "Store",
  brand: "Brand",
  isArchived: "Archived?",
  notes: "Notes",  
  createdAt: "Created At",
  updatedAt: "Updated At",
}