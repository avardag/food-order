import { useState, useEffect } from "react";
import { CartContext } from "../context/CartContext";
import { ICartItem, Food } from "../shared/types";

//constants for cart in <LocalStorage>
const CART_KEY = "cartItems";

interface CartState {
  items: ICartItem[];
  totalPrice: number;
  totalQuantity: number;
}

const EMPTY_CART: CartState = {
  items: [],
  totalPrice: 0,
  totalQuantity: 0,
};

interface CartStoreProviderProps {
  children: JSX.Element | JSX.Element[];
  //children: React.ReactNode
}

export const CartStoreProvider = ({ children }: CartStoreProviderProps) => {
  const initState = getCartFromLocalStorage();
  const [cartItems, setCartItems] = useState<ICartItem[]>(
    initState.items || []
  );
  const [totalPrice, setTotalPrice] = useState(initState.totalPrice || 0);
  const [totalQuantity, setTotalQuantity] = useState(
    initState.totalQuantity || 0
  );

  //get cart state from localStorage.
  function getCartFromLocalStorage(): CartState {
    const persistedCart = localStorage.getItem(CART_KEY);
    return persistedCart ? JSON.parse(persistedCart) : EMPTY_CART;
  }

  useEffect(() => {
    const totalPrice = cartItems.reduce(
      (acc, curr) => acc + curr.product.price * curr.quantity,
      0
    );
    const totalCount = cartItems.reduce((acc, curr) => acc + curr.quantity, 0);
    setTotalPrice(totalPrice);
    setTotalQuantity(totalCount);

    localStorage.setItem(
      CART_KEY,
      JSON.stringify({
        items: cartItems,
        totalPrice,
        totalQuantity,
      })
    );
  }, [cartItems, totalQuantity]);

  const addItemToCart = (product: Food) => {
    // Copy the current cart items
    const currentCartItems = [...cartItems];

    // Find the index of the product in the cart
    const existingCartItem = currentCartItems.find(
      (item) => item.product.id === product.id
    );

    // If the product is already in the cart, update the quantity
    if (existingCartItem) {
      existingCartItem.quantity += 1;
    } else {
      // If the product is not in the cart, add it
      currentCartItems.push({
        product,
        quantity: 1,
      });
    }

    // Update the cart items
    setCartItems(currentCartItems);
  };

  ////removes single item
  // const removeItemFromCart = (product: Food) => {
  //   // make a copy of the cart items
  //   const currentCartItems = [...cartItems];
  //
  //   // find the index of the product in the cart
  //   const existingCartItem = currentCartItems.find(
  //     (item) => item.product.id === product.id,
  //   );
  //
  //   // if the product exists in the cart
  //   if (existingCartItem) {
  //     if (existingCartItem.quantity > 1) {
  //       // minus quantity by one
  //       existingCartItem.quantity -= 1;
  //     } else {
  //       // remove the whole cart item
  //       currentCartItems.splice(currentCartItems.indexOf(existingCartItem), 1);
  //     }
  //   } else {
  //     throw new Error("removeFromCart: Product does not exist.");
  //   }
  //
  //   setCartItems(currentCartItems);
  // };

  //removes item completely from cart
  const removeItemFromCart = (product: Food) => {
    const filteredItems = cartItems.filter(
      (item) => item.product.id !== product.id
    );
    setCartItems(filteredItems);
  };

  const changeItemQuantity = (cartItem: ICartItem, newQuantity: number) => {
    const { product } = cartItem;

    const changedCartItem = {
      ...cartItem,
      quantity: newQuantity,
    };

    setCartItems(
      cartItems.map((item) =>
        item.product.id === product.id ? changedCartItem : item
      )
    );
  };

  const emptyCart = () => {
    setCartItems([]);
  };

  return (
    <CartContext.Provider
      value={{
        cartItems,
        totalQuantity,
        totalPrice,
        emptyCart,
        addItemToCart,
        removeItemFromCart,
        changeItemQuantity,
      }}
    >
      {children}
    </CartContext.Provider>
  );
};
