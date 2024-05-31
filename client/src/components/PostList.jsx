import { Fragment, useContext, useEffect, useState } from "react";
import { getPublicPosts } from "../managers/postManager";
import { Link } from "react-router-dom";
import { UserContext } from "../App";
import "./PostView.css";

const PostList = () => {
  const user = useContext(UserContext);
  const [posts, setPosts] = useState([]);

  useEffect(() => {
    getPublicPosts().then((posts) => {
      setPosts(
        posts.sort((a, b) => new Date(b.publication) - new Date(a.publication))
      );
    });
  }, []);

  return (
    <main>
      <div className="PostList-div-maincontainer">
        <section className="PostList-section-posts">
          {posts.map((p) => (
            <article key={"p" + p.id} className="PostList-post-border">
              <header className="PostList-post-header">
                {p.publication}{" "}
                {p.authorId == user.id && (
                  <Link to={`/post/${p.id}/edit`}>edit</Link>
                )}
              </header>
              {p.imageURL == null || "" ? (
                <img
                  src={
                    "https://resources.alleghenycounty.us/css/images/Default_No_Image_Available.png"
                  }
                />
              ) : (
                <img src={p.imageURL} />
              )}
              <div>
                <Link to={`/post/${p.id}`} className="PostList-linkto-post">
                  <div>{p.title}</div>
                </Link>

                <div>{p.author.fullName}</div>
                <div>{p.category.categoryName}</div>
              </div>
            </article>
          ))}
        </section>
      </div>
    </main>
  );
};

export default PostList;
