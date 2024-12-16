import { Link } from "react-router-dom";
import { Food } from "../../shared/types";
import StarRating from "../StarRating";
import Price from "../Price";

export default function Thumbnails({ foods }: { foods: Food[] }) {
  return (
    <ul className="flex justify-center items-center flex-wrap">
      {foods.map((food) => (
        <li key={food.id}>
          <Link
            to={`/food/${food.id}`}
            className="h-96 w-80 border flex flex-col overflow-hidden m-2 rounded-2xl border-solid border-gray-100"
          >
            <img
              className="object-cover h-52 w-full"
              src={`/foodImg/${food.imageUrl}`}
              alt={food.name}
            />

            <div className="relative mt-1 py-2 px-4 h-48 ">
              <h4 className="text-lg font-medium text-red-600">{food.name}</h4>
              <span
                className={`absolute top=1 right-4 text-red-500 ${
                  !food.favorite && "text-gray-400"
                }`}
              >
                ❤
              </span>
              <div className="my-2 mx-0">
                <StarRating stars={food.stars} />
              </div>
              <div className="flex justify-between items-start">
                <div className="flex-[9]">
                  {food.origins.map((origin) => (
                    <span
                      key={origin}
                      className="inline-block px-2 py-1 rounded-full bg-gray-200 text-gray-500 mr-2"
                    >
                      {origin}
                    </span>
                  ))}
                </div>
                <div className=" flex-[3] text-right text-gray-500">
                  {food.categoryName}
                </div>
              </div>
              <div className="absolute bottom-0 left-0 bg-white py-2 px-4 text-lg font-medium text-gray-800">
                <Price price={food.price} />
              </div>
            </div>
          </Link>
        </li>
      ))}
    </ul>
  );
}
