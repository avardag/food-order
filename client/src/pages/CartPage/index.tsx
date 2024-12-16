import { Link } from "react-router-dom";
import Price from "../../components/Price";
import Title from "../../components/Title";
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
        <div className="flex flex-wrap items-start mt-2 m-6">
          <ul className="flex flex-col flex-[3_0] justify-evenly border list-none m-2 p-0 rounded-2xl border-solid border-red-300">
            {cartItems.map((item) => (
              <li
                key={item.product.id}
                className="p-4 flex justify-around items-center flex-wrap border-b-gray-100 border-b border-solid last:border-none"
              >
                <div>
                  <img
                    // src={`${item.product.imageUrl}`}
                    src={`foodImg/${item.product.imageUrl}`}
                    alt={item.product.name}
                    className="w-20 h-20 object-cover rounded-full"
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
                    className="w-12 text-xl font-thin border-b-gray-400  border-b outline-none"
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
                    className="text-red-600 opacity-70 p-2 rounded-2xl border-none hover:opacity-100 hover:cursor-pointer outline-none"
                    onClick={() => removeItemFromCart(item.product)}
                  >
                    Remove
                  </button>
                </div>
              </li>
            ))}
          </ul>

          <div className="flex flex-col justify-between items-center flex-[1_3] h-80 border m-2 p-2 rounded-2xl border-solid border-red-300">
            <div className="text-xl flex-[3] flex flex-col justify-center items-start m-4">
              <div className="mb-6">
                <span className="text-gray-500">Count: </span>
                {totalQuantity}
              </div>
              <div className="">
                <span className="text-gray-500">Price: </span>
                <Price price={totalPrice} />
              </div>
            </div>

            <Link
              to="/checkout"
              className="text-[white] bg-red-600 block w-[99%] text-center justify-self-center p-4 rounded-3xl hover:opacity-80 hover:cursor-pointer"
            >
              Proceed To Checkout
            </Link>
          </div>
        </div>
      )}
    </>
  );
}
