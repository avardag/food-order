import { useEffect, useState } from "react";
import { Food, TagList } from "../../shared/types";
import {
  getAll,
  getAllFoodsByTag,
  getAllTags,
  searchFood,
} from "../../services/foodService";
import Thumbnails from "../../components/Thumbnails";
import { useParams } from "react-router-dom";
import Search from "../../components/Search";
import Tags from "../../components/Tags";
import NotFound from "../../components/NotFound";

export default function HomePage() {
  const [foods, setFoods] = useState<Food[]>([]);
  const [tags, setTags] = useState<TagList[]>([]);

  const { searchTerm, tagName } = useParams();

  useEffect(() => {
    const fetchFoods = async () => {
      const response = tagName
        ? await getAllFoodsByTag(tagName)
        : searchTerm
          ? await searchFood(searchTerm)
          : await getAll();
      // const data = await response.json();
      setFoods(response);
    };

    const fetchTags = async () => {
      const response = await getAllTags();
      setTags(response);
    };
    fetchFoods();
    fetchTags();
  }, [searchTerm, tagName]);

  return (
    <>
      <Search />
      <Tags tags={tags} showCount />
      {foods.length === 0 && <NotFound />}
      <Thumbnails foods={foods} />
    </>
  );
}
