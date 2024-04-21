import {sampleFoodItems, sampleTags} from "../data";
import {Food, TagList} from "../shared/types";

export const getAll = async (): Promise<Food[]> => sampleFoodItems as Food[];

export const searchFood = async (searchTerm: string): Promise<Food[]> => {
    // const foods = await getAll();
    return sampleFoodItems.filter(food => food.name.toLowerCase().includes(searchTerm.toLowerCase())) as Food[]
}

export const getAllTags = async (): Promise<TagList[]> => sampleTags
;

export const getAllFoodsByTag = async (tagName: string): Promise<Food[]> => {
    if (tagName === 'All') return await getAll();
    return sampleFoodItems.filter(food => food.tags?.includes(tagName)) as Food[]
}