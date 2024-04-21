import {Food, TagList } from "./shared/types"

export const sampleFoodItems:Food[] = [
    {
        id: 1,
        name: "Pizza",
        cookTime: "10-20",
        price: 10,
        favorite: false,
        origins: ["italy"],
        stars: 4.5,
        imageUrl: "chad-montano-MqT0asuoIcU-unsplash.jpg",
        tags: ["Fast", "Pizza"],
    },
    {
        id: 2,
        name: "Meatball",
        price: 20,
        cookTime: "20-30",
        favorite: true,
        origins: ["persia", "middle east", "china"],
        stars: 4.7,
        imageUrl: "emiliano-vittoriosi-OFismyezPnY-unsplash.jpg",
        tags: ["Meat"],
    },
    {
        id: 3,
        name: "Veggie",
        price: 8,
        cookTime: "15-25",
        favorite: false,
        origins: ["india", "asia"],
        stars: 4.0,
        imageUrl: "heather-ford-Ug7kk0kThLk-unsplash.jpg",
        tags: ["Vegan", "Lunch"],
    },
    {
        id: 4,
        name: "Hamburger",
        price: 10,
        cookTime: "10-15",
        favorite: false,
        origins: ["germany", "us"],
        stars: 3.5,
        imageUrl: "lidye-1Shk_PkNkNw-unsplash.jpg",
        tags: ["Burger", "Meat"],
    },
    {
        id: 5,
        name: "Pancake with bananas",
        price: 2,
        cookTime: "15-20",
        favorite: true,
        origins: [ "france"],
        stars: 3.3,
        imageUrl: "chad-montano-eeqbbemH9-c-unsplash.jpg",
        tags: ["Breakfast", "Vegetarian"],
    },
    {
        id: 6,
        name: "Pasta",
        price: 15,
        cookTime: "15-25",
        favorite: true,
        origins: ["Italy"],
        stars: 4.0,
        imageUrl: "brooke-lark--F_5g8EEHYE-unsplash.jpg",
        tags: ["Pasta"],
    },
    {
        id: 7,
        name: "Vegeterian Sandwich",
        price: 12,
        cookTime: "10-15",
        favorite: false,
        origins: ["Sweden", "europe"],
        stars: 4.0,
        imageUrl: "asnim-ansari-SqYmTDQYMjo-unsplash.jpg",
        tags: [ "Lunch", "Vegetarian", "Fast"],
    }, {
        id: 8,
        name: "Tofu salad",
        price: 10,
        cookTime: "10-15",
        favorite: false,
        origins: ["japan", "asia"],
        stars: 3.5,
        imageUrl: "anh-nguyen-kcA-c3f_3FE-unsplash.jpg",
        tags: ["Vegan", "Lunch"],
    }
]

export const sampleTags:TagList[] = [
    {name: "All", count: 8},
    {name: "Fast", count: 2},
    {name: "Pizza", count: 2},
    {name: "Vegan", count: 2},
    {name: "Meat", count: 1},
    {name: "Breakfast", count: 1},
    {name: "Lunch", count: 3},
    {name: "Vegetarian", count: 2},
    {name: "Pasta", count: 1},    
]