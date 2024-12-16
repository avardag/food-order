import axios from "axios";
import { Food, TagWithCount } from "../shared/types";

export const getAll = async (): Promise<Food[]> => {
  const { data } = await axios.get("/api/food");
  return data;
};

export const searchFood = async (searchTerm: string): Promise<Food[]> => {
  try {
    const { data } = await axios.get("/api/food/search/" + searchTerm);
    return data;
  } catch (err) {
    return [];
  }
};

export const getAllTags = async (): Promise<TagWithCount[]> => {
  try {
    const { data } = await axios.get("/api/tag");
    return data;
  } catch (err) {
    return [];
  }
};

export const getAllFoodsByTag = async (tagName: string): Promise<Food[]> => {
  if (tagName === "All") return await getAll();
  try {
    const { data } = await axios.get("/api/food/tag/" + tagName);
    return data;
  } catch (err) {
    return [];
  }
};

export const getFoodById = async (id: number): Promise<Food | null> => {
  try {
    const { data } = await axios.get("/api/food/" + id);
    return data;
  } catch (err) {
    console.log(err);
    return null;
  }
};
