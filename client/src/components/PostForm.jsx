import { useEffect, useState } from "react"
import { getAllCategories } from "../managers/categories"

const PostForm = () =>
{
    const [categories, setCategories] = useState([])

    useEffect(
        () =>
        {
            getAllCategories().then(setCategories)
        }, []
    )

    return <div>
        <div>
            <label htmlFor="title">Title: </label>
            <input type="text" id="title" />
        </div>
        <div>
            <label htmlFor="body">Body: </label>
            <input type="text" id="body" />
        </div>
        <select>
            <option defaultChecked>Select A Category</option>
            {
                categories.map(c =>
                    <option key={"c" + c.id}>{c.categoryName}</option>)
            }
        </select>
        <div>
            <label htmlFor="image">Header URL: </label>
            <input type="text" id="image" />
        </div>
        <div>
            <label htmlFor="date">Header URL: </label>
            <input type="date" id="date" />
        </div>
    </div>
}

export default PostForm