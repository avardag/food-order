import axios from "axios";
import { Food, Tag } from "../shared/types";

export const getAll = async (): Promise<Food[]> => {
  const { data } = await axios.get("/api/food");
  return data;
};

export const searchFood = async (searchTerm: string): Promise<Food[]> => {
  const { data } = await axios.get("/api/food/search/" + searchTerm);
  return data;
};

export const getAllTags = async (): Promise<Tag[]> => {
  const { data } = await axios.get("/api/tag");
  return data;
};

export const getAllFoodsByTag = async (tagName: string): Promise<Food[]> => {
  if (tagName === "All") return await getAll();
  const { data } = await axios.get("/api/food/tag/" + tagName);
  return data;
};

export const getById = async (id: number): Promise<Food> => {
  const { data } = await axios.get("/api/food/" + id);
  return data;
};
