import { Fragment, useEffect, useState } from "react"
import { getAllCategories } from "../managers/categories"
import { getAllTags } from "../managers/tags"

const PostForm = ({ initialPost, onPostSubmitted }) =>
{
    const [categories, setCategories] = useState([])
    const [allTags, setAllTags] = useState([])
    const [title, setTitle] = useState("")
    const [body, setBody] = useState("")
    const [categoryId, setCategoryId] = useState(0)
    const [image, setImage] = useState()
    const [date, setDate] = useState(new Date().toISOString().slice(0, 10))
    const [tagIds, setTagIds] = useState([])

    useEffect(
        () =>
        {
            getAllCategories().then(setCategories)
            getAllTags().then(setAllTags)
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
                setTagIds(initialPost.tagIds)
            }
        }, [initialPost]
    )

    const onSubmit = () =>
    {
        if(postIsValid())
        {
            const formData = new FormData()
            formData.append("formFile", image)
            formData.append("title", title)
            formData.append("content", body)
            formData.append("categoryId", categoryId)
            formData.append("publication", date)
            formData.append("tagIds", tagIds)

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

    const onTagChanged = (tagId, checked) =>
    {
        if(checked)
        {
            setTagIds([...tagIds, tagId])
        } else
        {
            setTagIds(tagIds.filter(t => t != tagId))
        }
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
            <label htmlFor="img-input">Header Image: </label>
            <input onChange={(e) => setImage(e.target.files[0])} type="file" id="img-input"></input>
        </div>
        <div>
            <label htmlFor="date">Publish Date: </label>
            <input type="date" id="date" value={date} onChange={(e) => setDate(e.target.value)} />
        </div>
        {
            allTags.map(t =>
            {
                const id = `t${t.id}`
                return (
                    <Fragment key={id}>
                        <label htmlFor={id}>{t.tagName}</label>
                        <input checked={tagIds.includes(t.id)} onChange={(e) => onTagChanged(t.id, e.target.checked)} type="checkbox" id={id} />
                    </Fragment>
                )
            }

            )
        }
        <div>
            <button onClick={onSubmit}>Submit</button>
        </div>
    </div>
}

export default PostForm