import { useState } from "react";
import { postNewCategory } from "../../../managers/categories";
import { useNavigate } from "react-router-dom";
import { addATag } from "../../../managers/tags";

export const TagsCreate = () => {
  const [tag, setTag] = useState("");
  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();

    if (tag != "") {
      addATag({ TagName: tag }).then(() => {
        navigate(`/tags`);
      });
    }
  };

  return (
    <main>
      <div className="CategoriesCreate-div-container">
        <form onSubmit={handleSubmit}>
          <article className="CategoriesCreate-article-container">
            <input
              required
              className="CategoriesCreate-input-categoryName"
              value={tag}
              onChange={(e) => {
                setTag(e.target.value);
              }}
            />
            <section>
              <button className="CategoriesCreate-button-submit" type="submit">
                Submit
              </button>
            </section>
          </article>
        </form>
      </div>
    </main>
  );
};
