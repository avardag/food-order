import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Food } from "../../shared/types";
import StarRating from "../../components/StarRating";
import Tags from "../../components/Tags";
import Price from "../../components/Price";
import { getFoodById } from "../../services/foodService";
import useCart from "../../hooks/useCart";
import NotFound from "../../components/NotFound";

export default function FoodPage() {
  const [food, setFood] = useState<Food | null>(null);
  const { foodId } = useParams();
  const { addItemToCart } = useCart();
  const navigate = useNavigate();

  const handleAddToCart = () => {
    if (food !== null) {
      addItemToCart(food);
      navigate("/cart");
    }
  };

  useEffect(() => {
    const fetchFood = async () => {
      if (foodId) {
        const response = await getFoodById(Number.parseInt(foodId, 10));
        setFood(response);
      }
    };
    fetchFood();
  }, [foodId]);
  return (
    <>
      {!food ? (
        <NotFound message="Food not found" linkText="Back to home page" />
      ) : (
        <div className="flex justify-center items-center flex-wrap m-12">
          <img
            className="min-w-96 max-w-[40rem] flex-[1_0] object-cover h-[35rem] m-4 rounded-3xl"
            src={`/foodImg/${food.imageUrl}`}
            alt={food.name}
          />

          <div className="min-w-96 max-w-[40rem] w-full flex flex-col flex-[1_0] text-gray-950 ml-4 p-8 rounded-3xl">
            <div className="flex justify-between">
              <span className="text-4xl font-bold">{food.name}</span>
              <span
                className={`text-4xl ${
                  food.favorite ? "text-red-600" : "text-gray-400"
                }`}
              >
                ❤
              </span>
            </div>
            <div className="">
              <StarRating stars={food.stars} size={25} />
            </div>

            <div className="flex flex-wrap mx-0 my-3">
              {food.origins?.map((origin) => (
                <span
                  key={origin}
                  className="text-xl bg-blue-100 ml-0 mr-2 mt-2 mb-0 p-2 rounded-full"
                >
                  {origin}
                </span>
              ))}
            </div>

            <div className="">
              {food.tagNames && (
                <Tags tags={food.tagNames.map((tag) => ({ name: tag }))} />
              )}
            </div>

            <div className="text-xl mt-4 pl-0 pr-8 py-2 rounded-3xl">
              {food.description}
            </div>

            <div className="text-2xl text-green-600 ml-0 mr-8 my-8 before:content-['Price:'] before:text-gray-400">
              <Price price={food.price} />
            </div>

            <button
              className="text-white bg-red-600 text-4xl p-4 rounded-full border-none hover:opacity-90 hover:cursor-pointer"
              onClick={handleAddToCart}
            >
              Add To Cart
            </button>
          </div>
        </div>
      )}
    </>
  );
}
