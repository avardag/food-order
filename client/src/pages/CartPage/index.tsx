import { Link } from "react-router-dom";
import Price from "../../components/Price";
import Title from "../../components/Title";
import types from "./cartPage.module.css";
import useCart from "../../hooks/useCart";
import NotFound from "../../components/NotFound";
// import NotFound from '../../components/NotFound/NotFound';

export default function CartPage() {
  const {
    cartItems,
    removeItemFromCart,
    totalQuantity,
    totalPrice,
    changeItemQuantity,
  } = useCart();
  return (
    <>
      <Title title="Cart Page" margin="1.5rem 0 0 2.5rem" />

      {cartItems.length === 0 ? (
        <NotFound message="Your Cart is empty" />
      ) : (
        <div className={types.container}>
          <ul className={types.list}>
            {cartItems.map((item) => (
              <li key={item.product.id}>
                <div>
                  <img
                    // src={`${item.product.imageUrl}`}
                    src={`foodImg/${item.product.imageUrl}`}
                    alt={item.product.name}
                  />
                </div>
                <div>
                  <Link to={`/food/${item.product.id}`}>
                    {item.product.name}
                  </Link>
                </div>

                <div>
                  <select
                    value={item.quantity}
                    onChange={(e) =>
                      changeItemQuantity(item, Number(e.target.value))
                    }
                  >
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>
                    <option>6</option>
                    <option>7</option>
                    <option>8</option>
                    <option>9</option>
                    <option>10</option>
                  </select>
                </div>

                <div>
                  <Price price={item.product.price} />
                </div>

                <div>
                  <button
                    className={types.remove_button}
                    onClick={() => removeItemFromCart(item.product)}
                  >
                    Remove
                  </button>
                </div>
              </li>
            ))}
          </ul>

          <div className={types.checkout}>
            <div>
              <div className={types.foods_count}>{totalQuantity}</div>
              <div className={types.total_price}>
                <Price price={totalPrice} />
              </div>
            </div>

            <Link to="/checkout">Proceed To Checkout</Link>
          </div>
        </div>
      )}
    </>
  );
}
