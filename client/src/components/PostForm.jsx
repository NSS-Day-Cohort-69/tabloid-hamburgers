import { useEffect, useState } from "react"
import { getAllCategories } from "../managers/categories"

const PostForm = ({ initialPost, onPostSubmitted }) =>
{
    const [categories, setCategories] = useState([])
    const [title, setTitle] = useState("")
    const [body, setBody] = useState("")
    const [categoryId, setCategoryId] = useState(0)
    const [imageURL, setImageURL] = useState("")
    const [date, setDate] = useState(new Date().toISOString().slice(0, 10))

    useEffect(
        () =>
        {
            getAllCategories().then(setCategories)
        }, []
    )

    useEffect(
        () =>
        {
            if(initialPost)
            {
                setTitle(initialPost.title)
                setBody(initialPost.content)
                setCategoryId(initialPost.categoryId)
                setImageURL(initialPost.imageURL ? initialPost.imageURL : "")
                setDate(new Date(initialPost.publication).toISOString().slice(0, 10))
            }
        }, [initialPost]
    )

    const onSubmit = () =>
    {
        if(postIsValid())
        {
            const post =
            {
                title: title,
                content: body,
                imageURL: imageURL,
                categoryId: categoryId,
                publication: date
            }

            onPostSubmitted(post)
        } else
        {
            window.alert("post is invalid")
        }
    }

    const postIsValid = () =>
    {
        return title != "" && body != "" && categoryId != 0
    }

    return <div>
        <div>
            <label htmlFor="title">Title: </label>
            <input type="text" id="title" value={title} onChange={(e) => { setTitle(e.target.value) }} />
        </div>
        <div>
            <label htmlFor="body">Body: </label>
            <textarea id="body" value={body} onChange={(e) => { setBody(e.target.value) }} />
        </div>
        <select value={categoryId} onChange={(e) => setCategoryId(e.target.value)}>
            <option value={0}>Select A Category</option>
            {
                categories.map(c =>
                    <option value={c.id} key={"c" + c.id}>{c.categoryName}</option>)
            }
        </select>
        <div>
            <label htmlFor="image">Header URL: </label>
            <input type="text" id="image" value={imageURL} onChange={(e) => setImageURL(e.target.value)} />
        </div>
        <div>
            <label htmlFor="date">Publish Date: </label>
            <input type="date" id="date" value={date} onChange={(e) => setDate(e.target.value)} />
        </div>
        <div>
            <button onClick={onSubmit}>Submit</button>
        </div>
    </div>
}

export default PostForm