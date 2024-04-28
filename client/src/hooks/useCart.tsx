import { useContext } from "react";
import { CartContext, ICartContext } from "../context/CartContext";

const useCart = () => {
  const {
    cartItems,
    addItemToCart,
    removeItemFromCart,
    emptyCart,
    totalPrice,
    totalQuantity,
    changeItemQuantity,
  } = useContext(CartContext) as ICartContext;

  return {
    cartItems,
    totalQuantity,
    totalPrice,
    emptyCart,
    addItemToCart,
    removeItemFromCart,
    changeItemQuantity,
  };
};

export default useCart;
