export interface Food {
  id: number;
  name: string;
  description: string;
  price: number;
  favorite?: boolean;
  origins: string[];
  stars: number;
  imageUrl: string;
  tagNames: string[];
  categoryName: string;
}

export interface Tag {
  id: string;
  name: string;
}

export interface TagWithCount extends Tag {
  count: number;
}

export interface Category {
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

export interface IUserRegisterDto {
  username: string;
  email: string;
  password: string;
  firstName?: string;
  lastName?: string;
}

export type CustomError = {
  message: string;
  error?: string;
  statusCode?: number;
};
