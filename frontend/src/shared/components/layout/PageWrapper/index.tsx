import type { BreadcrumbItem } from "../Breadcrumb"
import Breadcrumb from "../Breadcrumb"

type HeaderMode = { mode: "breadcrumb"; title: string; subtitle?: string; items: BreadcrumbItem[] } | { mode: "none" }

type Props = {
    children: React.ReactNode
    sideChildren?: React.ReactNode
    header?: HeaderMode
    bgColor?: string
}

const PageWrapper = ({ children, sideChildren, header = { mode: "none" }, bgColor }: Props) => {
    const hasHeader = header.mode !== "none"

    return (
        <div className={`flex-1 flex flex-col w-full ${bgColor}`}>
            {hasHeader && (
                <div className="w-full">
                    {header.mode === "breadcrumb" && (
                        <div className="w-full flex flex-col items-center">
                            <Breadcrumb items={header.items} />
                            <div className="w-full flex max-w-6xl justify-center items-center py-1">
                                <div className="w-full py-2 pl-4 flex flex-col gap-2">
                                    <h1 className="tracking-tight text-3xl align-self-end font-semibold">
                                        {header.title}
                                    </h1>
                                    {header.subtitle && (
                                        <h2 className="tracking-tight text-md align-self-end text-text-sub">
                                            {header.subtitle}
                                        </h2>
                                    )}
                                </div>
                                {sideChildren && <div>{sideChildren}</div>}
                            </div>
                        </div>
                    )}
                </div>
            )}

            <div className="flex-1 flex flex-col w-full items-center max-w-6xl mx-auto px-4">{children}</div>
        </div>
    )
}

export default PageWrapper
