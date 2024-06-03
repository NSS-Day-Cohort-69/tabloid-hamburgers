import { useEffect, useState } from "react"
import { getPostByAuthorId } from "../../managers/usersPostManager.js"

const PostByAuthor =({loggedInUser}) => {
    const [post, setPost] = useState([])

    useEffect(() => {
        const getData = () => {
        } 

        if (loggedInUser != null)
            {
                const postData = getPostByAuthorId(loggedInUser.id).then(setPost);
                    }

        getData()
    }, [loggedInUser])
    return (
        <div>
            <h1>My Posts </h1>
            {post.map((p) => (
                <div key={p.id}>
                    <div>{p.title}</div>
                    <div>{p.author}</div>
                    <div>{p.category}</div>
                    <div>{p.publication}</div>
                </div>
            ))}
        </div>
    )
}

export default PostByAuthor;