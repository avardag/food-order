import { createContext } from "react";
import { ICartItem, Food } from "../shared/types";

export interface ICartContext {
  cartItems: ICartItem[];
  totalPrice: number;
  totalQuantity: number;
  removeItemFromCart: (product: Food) => void;
  addItemToCart: (product: Food) => void;
  changeItemQuantity: (cartItem: ICartItem, newQuantity: number) => void;
  emptyCart: () => void;
}

export const CartContext = createContext<ICartContext | null>(null);
