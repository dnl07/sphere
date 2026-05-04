export interface ClothingItemDto {
  id: string;
  category: string | null;
  description?: string | null;
  size?: string | null;
  material?: string | null;
  color?: string | null;
  price?: PriceDto;
  boughtAt?: Date,
  store?: string | null,
  brand?: string | null,
  isArchived: false,
  notes?: string | null,  
  imageId: string;
  createdAt?: Date;
  updatedAt?: Date;
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