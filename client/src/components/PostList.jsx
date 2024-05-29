import { useEffect, useState } from "react"
import { getPosts } from "../managers/postManager"

const PostList = () =>
{
    const [posts, setPosts] = useState([])

    useEffect(
        () =>
        {
            getPosts().then(setPosts)
        }, []
    )

    return <>post list</>
}

export default PostList