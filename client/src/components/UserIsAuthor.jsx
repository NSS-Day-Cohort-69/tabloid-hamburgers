import { useContext, useEffect, useState } from "react"
import { useParams } from "react-router-dom"
import { UserContext } from "../App"
import { getPostById } from "../managers/postManager"

const UserIsAuthor = ({ children }) =>
{
    const user = useContext(UserContext)
    const { postId } = useParams()
    const [post, setPost] = useState({})

    useEffect(
        () =>
        {
            getPostById(postId).then(setPost)
        }, [postId]
    )

    return user.id == post.authorId 
        ? <>{children}</>
        : <>You do not own this post.</>
}

export default UserIsAuthor