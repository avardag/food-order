import { sampleFoodItems } from "../data";
import { Food } from "../shared/types";

export const getAll = async (): Promise<Food[]> => sampleFoodItems as Food[];

export const searchFood = async (searchTerm: string): Promise<Food[]> => {
    // const foods = await getAll();
    return sampleFoodItems.filter(food => food.name.toLowerCase().includes(searchTerm.toLowerCase())) as Food[]
}