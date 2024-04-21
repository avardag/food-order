import {useEffect, useReducer} from "react"
import { Food } from "../../shared/types"
import { getAll, searchFood } from "../../services/foodService"
import Thumbnails from "../../components/Thumbnails"
import {useParams} from "react-router-dom";
import Search from "../../components/Search";

interface FoodState {
    foods: Food[]
}
const initState: FoodState = {
    foods: []
}
// An enum with all the types of actions to use in our reducer
enum ActionType {
    FOODS_LOADED = "FOODS_LOADED"
}
interface FoodAction {
    type: ActionType
    payload: Food[]
}

const foodReducer = (state: FoodState = initState, action: FoodAction) => {
    switch (action.type) {
        case ActionType.FOODS_LOADED:
            return {
                ...state,
                foods: action.payload
            }
        default:
            return state
    }
}
export default function HomePage() {
    const [state, dispatch] = useReducer(foodReducer, initState);
    const {foods} = state;
    
    const {searchTerm} = useParams();
    
    useEffect(() => {
        const fetchFoods = async () => {
            const response = searchTerm ? await searchFood(searchTerm) :  await getAll();
            // const data = await response.json();
            dispatch({type: ActionType.FOODS_LOADED, payload: response})
        }
        fetchFoods();
        
    }, [searchTerm])

    return (
        <>
            <Search/>
            <Thumbnails foods={foods}/></>
    )
}
