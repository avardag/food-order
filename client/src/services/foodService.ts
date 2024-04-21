import { sampleFoodItems } from "../data";
import { Food } from "../shared/types";

export const getAll = async (): Promise<Food[]> => sampleFoodItems as Food[];