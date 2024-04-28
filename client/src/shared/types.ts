export interface Food {
  id: number;
  name: string;
  price: number;
  cookTime: string;
  favorite: boolean;
  origins: string[];
  stars: number;
  imageUrl: string;
  tags: string[];
}

export interface TagList {
  name: string;
  count?: number;
}

export interface ICartItem {
  product: Food;
  quantity: number;
}

