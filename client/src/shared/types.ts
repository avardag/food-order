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

export interface Tag {
  id: string;
  name: string;
}

export interface ICartItem {
  product: Food;
  quantity: number;
}

export interface IUser {
  userName: string;
  email: string;
  token: string;
  role: "Admin" | "User";
}

export interface LoginInput {
  email: string;
  password: string;
}
