import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import styles from "./foodPage.module.css";
import { Food } from "../../shared/types";
import StarRating from "../../components/StarRating";
import Tags from "../../components/Tags";
import Price from "../../components/Price";
import { getById } from "../../services/foodService";
import useCart from "../../hooks/useCart";

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
        const response = await getById(Number.parseInt(foodId, 10));
        setFood(response);
      }
    };
    fetchFood();
  }, [foodId]);
  return (
    <>
      {!food ? (
        <h1>Food not found</h1>
      ) : (
        <div className={styles.container}>
          <img
            className={styles.image}
            src={`/foodImg/${food.imageUrl}`}
            alt={food.name}
          />

          <div className={styles.details}>
            <div className={styles.header}>
              <span className={styles.name}>{food.name}</span>
              <span
                className={`${styles.favorite} ${
                  food.favorite ? "" : styles.not
                }`}
              >
                ❤
              </span>
            </div>
            <div className={styles.rating}>
              <StarRating stars={food.stars} size={25} />
            </div>

            <div className={styles.origins}>
              {food.origins?.map((origin) => (
                <span key={origin}>{origin}</span>
              ))}
            </div>

            <div className={styles.tags}>
              {food.tags && (
                <Tags tags={food.tags.map((tag) => ({ name: tag }))} />
              )}
            </div>

            <div className={styles.cook_time}>
              <span>
                Time to cook about <strong>{food.cookTime}</strong> minutes
              </span>
            </div>

            <div className={styles.price}>
              <Price price={food.price} />
            </div>

            <button onClick={handleAddToCart}>Add To Cart</button>
          </div>
        </div>
      )}
    </>
  );
}

