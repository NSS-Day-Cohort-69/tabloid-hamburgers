import { useEffect } from "react"
import { useParams } from "react-router-dom"
import { UserContext } from "../App"

const UserIsAuthor = ({ children }) =>
{
    const user = useContext(UserContext)
    const { postId } = useParams()

    return user.id == postId
        ? <>{children}</>
        : <>You do not own this post.</>
}

export default UserIsAuthor